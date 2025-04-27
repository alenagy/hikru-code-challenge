using HikruCodeChallenge.Domain.Enums;

namespace HikruCodeChallenge.Domain.Entities
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public PositionStatus Status { get; set; }
        public Guid RecruiterId { get; set; }
        public Guid DepartmentId { get; set; }
        public decimal Budget { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
