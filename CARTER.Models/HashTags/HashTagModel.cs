namespace CARTER.Models.HashTags
{
    public class HashTagModel
    {
        public int Id { get; set; }
        //public int? TagId { get; set; }
        public TagModel Tag { get; set; }

        //public Guid? SessionId { get; set; }
        //public SessionModel Session { get; set; }

        //public Guid? ExerciseId { get; set; }
        //public ExerciseModel Exercise { get; set; }
    }
}
