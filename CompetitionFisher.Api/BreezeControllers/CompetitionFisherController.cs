using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using CompetitionFisher.Api.Controllers;
using CompetitionFisher.Api.Infrastructure;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.Entities;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace CompetitionFisher.Api.BreezeControllers
{
    [BreezeController]
    public class CompetitionFisherController : ApiController
    {
        EFContextProvider<ApplicationDbContext> _contextProvider = new EFContextProvider<ApplicationDbContext>();

        public CompetitionFisherController()
        {
            _contextProvider.BeforeSaveEntityDelegate += beforeSaveEntity;
        }

        #region Breeze Tooling

        private bool beforeSaveEntity(EntityInfo entityInfo)
        {
            //if (entityInfo.Entity.GetType() == typeof(Contestant))
            //{
            //    var contestant = (Contestant)entityInfo.Entity;
            //    if (contestant.LastName == "Pipo") throw new ArgumentException("Pipo is an invalid lastname");
            //}
            //return CustomerLogic.OnSaveCustomer((Customer)entityInfo.Entity);

            return true;
        }

        //private Dictionary<Type, List<EntityInfo>> beforeSaveEntities(Dictionary<Type, List<EntityInfo>> entityInfos)
        //{
        //    if (entityInfos.ContainsKey(typeof(Order)))
        //    {
        //        var orders = entityInfos[typeof(Order)];
        //        var orderTotal = 0m;
        //        orders.ForEach(o => orderTotal += ((Order)o.Entity).ItemsTotal);
        //        if (orderTotal > 10.0m)
        //            throw new ArgumentException("Order total exceeds single call policy");
        //    }
        //    return entityInfos;
        //}

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject bundle)
        {
            return _contextProvider.SaveChanges(bundle);
        }

        #endregion

        [HttpGet]
        public IQueryable<Contestant> Contestants()
        {
            return _contextProvider.Context.Contestants;
        }


        [HttpGet]
        //[EnableBreezeQuery(AllowedQueryOptions = AllowedQueryOptions.All & ~(AllowedQueryOptions.OrderBy | AllowedQueryOptions.Top | AllowedQueryOptions.Skip))]
        //[EnableBreezeQuery(MaxExpansionDepth = 1)]
        public IQueryable<Championship> Championships()
        {
            //var user = ClaimsPrincipal.Current.Identity.Name;
            //// Lookup state that user is responsible for
            //var userState = "MO";
            //return _contextProvider.Context.Customers.Where(c => c.State == userState);
            return _contextProvider.Context.Championships;
        }

        [HttpGet]
        //[Authorize]
        [ScopeAuthorize("read:messages")]
        public IQueryable<Message> Messages()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string temp = this.Auth0UserId();
            return _contextProvider.Context.Messages;
        }

        [HttpGet]
        public IQueryable<Competition> Competitions()
        {
            return _contextProvider.Context.Competitions;
        }


        [HttpGet]
        public IQueryable<Result> Results()
        {
            return _contextProvider.Context.Results;
        }

        //[HttpGet]
        //public IQueryable<ApplicationUser> ApplicationUsers()
        //{
        //    return _contextProvider.Context.ApplicationUsers;
        //}

        [HttpGet]
        public object Lookups()
        {
            return new
            {
                //OrderStatuses = _contextProvider.Context.OrderStatuses,
                //ProductOptions = _contextProvider.Context.ProductOptions,
                //ProductSizes = _contextProvider.Context.ProductSizes
            };
        }
    }
}