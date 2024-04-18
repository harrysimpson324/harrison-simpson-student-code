using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{

    public class CatController : ControllerBase
    {
        private readonly ICatCardDao cardDao;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDao cardDao, ICatFactService catFactService, ICatPicService catPicService)
        {
            this.catFactService = catFactService;
            this.catPicService = catPicService;
            this.cardDao = cardDao;
        }


    }
}
