﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public class NganhCommandServiceImpl : IAddNganhService,IDeleteNganhService,IEditNganhService
    {
        INganhRepository nganhRepository;
        IKhoaRepository khoaRepository;

        public NganhCommandServiceImpl(INganhRepository nganhRepository,IKhoaRepository khoaRepository)
        {
            this.nganhRepository = nganhRepository;
            this.khoaRepository = khoaRepository;
        }

        public bool addNewNganh(AddNganhDto nganh)
        {
            Nganh ngh = nganhRepository.getAll().Where(ng => ng.manganh == nganh.maNganh).FirstOrDefault();
            if (ngh != null)
            {
                return false; // Nganh already exists
            }
            var khoa = khoaRepository.getAll().Where(k => k.tenkhoa == nganh.tenKhoa).FirstOrDefault().makhoa;
            nganhRepository.addNganh(new DataAccessLayer.Entity.Nganh
            
            {
                manganh = nganh.maNganh??"",
                tennganh = nganh.tenNganh??"",
                makhoa = khoa ?? "" 
            });
            return true;
        }

        public bool deleteNganhWithId(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return false; // Invalid ID
            }
            if(nganhRepository.getAll().Where(ng => ng.manganh == id).FirstOrDefault() == null)
            {
                return false; // Nganh not found
            }
            nganhRepository.deleteNganh(id);
            return true;
        }

        public bool editNganh(NganhDto nganh)
        {
            if(nganh == null || string.IsNullOrEmpty(nganh.maNganh))
            {
                return false; // Invalid Nganh data
            }
            Nganh existingNganh = nganhRepository.getAll().Where(ng => ng.manganh == nganh.maNganh).FirstOrDefault();
            if (existingNganh == null)
            {
                return false; // Nganh not found
            }
            existingNganh.manganh = nganh.maNganh ?? existingNganh.manganh;
            existingNganh.tennganh = nganh.tenNganh ?? existingNganh.tennganh;
            existingNganh.makhoa = nganhRepository.getAll().Where(ng => ng.Khoa.tenkhoa==nganh.khoa).FirstOrDefault().Khoa.makhoa?? existingNganh.makhoa;
            nganhRepository.editNganh(existingNganh);
            return true;
        }
    }
}
