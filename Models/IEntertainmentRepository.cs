namespace EntertainmentProject.Models
{
    public interface IEntertainmentRepository
    {
        List<Entertainer> Entertainers {  get; }

        //adding
        Task AddEntertainerAsync(Entertainer entertainer);

        //saving
        Task SaveChangesAsync();

        //listing
        Task<Entertainer> GetEntertainerByIdAsync(int entertainerId);

        //editing and updating
        Task UpdateEntertainerAsync(Entertainer entertainer);

        //detleting
        Task DeleteEntertainerAsync(Entertainer entertainer);
    }
}
