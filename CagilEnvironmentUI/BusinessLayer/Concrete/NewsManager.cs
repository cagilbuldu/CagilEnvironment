﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsManager:INewsService
    {
        private readonly INewsDal _newsDal;
        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public void Delete(News t)
        {
            _newsDal.Delete(t);
        }

        public List<News> GetAll()
        {
            return _newsDal.GetAll();   
        }

        public News GetById(int id)
        {
            return _newsDal.GetById(id);
        }

        public void Insert(News t)
        {
            _newsDal.Insert(t);
        }

        public void NewsStatusToFalse(int id)
        {
            _newsDal.NewsStatusToFalse(id);
        }

        public void NewsStatusToTrue(int id)
        {
            _newsDal.NewsStatusToTrue(id);
        }

        public void Update(News t)
        {
            _newsDal.Update(t);
        }
    }
}
