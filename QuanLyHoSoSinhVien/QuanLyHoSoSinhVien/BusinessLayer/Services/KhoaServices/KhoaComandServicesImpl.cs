using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices
{
    public class KhoaComandServicesImpl : IAddNewKhoaService,IDeleteKhoaService,IEditKhoaService
    {
        IKhoaRepository khoaRepository;

        public KhoaComandServicesImpl(IKhoaRepository khoaRepository)
        {
            this.khoaRepository = khoaRepository;
        }

        public bool add(AddKhoaDto khoa)
        {
            if (khoa!=null)
            {
                var entity = new Khoa
                {
                    makhoa = khoa.Id,
                    tenkhoa = khoa.tenKhoa
                };
                khoaRepository.AddNew(entity);
                return true;
            }
            return false;
        }

        public bool deleteKhoaById(string id)
        {
            Khoa khoaRemove = khoaRepository.GetByMa(id);
            if (khoaRemove != null)
            {
                khoaRepository.delete(khoaRemove);
                return true;
            }
            return false;
        }

        public bool editKhoa(KhoaDto newKhoa)
        {
            var k = new Khoa
            {
                makhoa = newKhoa?.maKhoa,
                tenkhoa = newKhoa?.tenKhoa
            };
            var khoa = khoaRepository.GetByMa(k.makhoa??"");
            if (khoa == null)
            {
                return false;
            }
            if (k != null)
            {
                khoaRepository.edit(k);
                return true;
            }
            return false;
        }
    }
}
