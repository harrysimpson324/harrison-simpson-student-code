using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Exceptions;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("/api/cards")]
    [ApiController]
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

        public ActionResult<IList<CatCard>> GetAllCards()
        {
            try
            {
                IList<CatCard> cards = cardDao.GetCatCards();
                return Ok(cards);
            }
            catch (DaoException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CatCard> GetCard(int id)
        {
            try
            {
                CatCard card = cardDao.GetCatCardById(id);
                if (card != null)
                {
                    return Ok(card);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (DaoException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("random")]
        public ActionResult<CatCard> GetRandomCard()
        {
            CatFact fact = catFactService.GetFact();
            CatPic pic = catPicService.GetPic();

            CatCard card = new CatCard()
            {
                CatFact = fact.Text,
                ImgUrl = pic.File
            };

            return card;
        }

        [HttpPost]
        public ActionResult<CatCard> SaveCard(CatCard incomingCard)
        {
            try
            {
                CatCard newCard = cardDao.CreateCatCard(incomingCard);
                return Created("/api/cards/" + newCard.CatCardId, newCard);
            }
            catch (DaoException)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateExistingCard(int id, CatCard changedCard)
        {
            // The id on the URL takes precedence over the one in the payload, if any
            changedCard.CatCardId = id;

            try
            {
                CatCard result = cardDao.UpdateCard(changedCard);
                return Ok(result);
            }
            catch (DaoException)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExistingCard(int id)
        {
            try
            {
                int cardsDeleted = cardDao.DeleteCatCardById(id);
                if (cardsDeleted == 0)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (DaoException)
            {
                return StatusCode(500);
            }
        }
    }
}
