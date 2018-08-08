using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST /api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            if (rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No Movie IDs are provided");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer ID is not valid");
            }

            // Translates to Select * from Movies where Id in (1,2,3)
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (rentalDto.MovieIds.Count != movies.Count)
            {
                return BadRequest("One or more Movie ID is invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                else
                {
                    movie.NumAvailable--;
                }

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newRental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
