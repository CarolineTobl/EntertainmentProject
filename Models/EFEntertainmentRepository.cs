
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EntertainmentProject.Models
{
    public class EFEntertainmentRepository : IEntertainmentRepository
    {
        private EntertainmentAgencyExampleContext _context;
        public EFEntertainmentRepository(EntertainmentAgencyExampleContext temp) 
        {
            _context = temp;
        }

        public List<Entertainer> Entertainers => _context.Entertainers.ToList();


        //Adding Entertainers
        public async Task AddEntertainerAsync(Entertainer entertainer)
        {
            await _context.Entertainers.AddAsync(entertainer);
        }


        //saving  changes to new entertainers
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        //getting entertainers for the details page
        public async Task<Entertainer> GetEntertainerByIdAsync(int entertainerId)
        {
            return await _context.Entertainers
                .FirstOrDefaultAsync(e => e.EntertainerId == entertainerId);
        }


        //editing the entertainer successfully
        public async Task UpdateEntertainerAsync(Entertainer entertainer)
        {
            _context.Update(entertainer);
            await _context.SaveChangesAsync();
        }

        //deleteing the entertainer
        public async Task DeleteEntertainerAsync(Entertainer entertainer)
        {
            _context.Entertainers.Remove(entertainer);
            await _context.SaveChangesAsync();
        }

    }
}
