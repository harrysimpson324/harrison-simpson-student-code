using CatCards.Models;
using System.Collections.Generic;

namespace CatCards.DAO
{
    public interface ICatCardDao
    {
        IList<CatCard> GetCatCards();

        CatCard GetCatCardById(int id);

        CatCard CreateCatCard(CatCard card);

        CatCard UpdateCard(CatCard card);

        int DeleteCatCardById(int id);
    }
}
