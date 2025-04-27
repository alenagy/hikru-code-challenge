using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikruCodeChallenge.Application.Positions.Dtos
{
    public class UpdatePositionDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
        public Guid? RecruiterId { get; set; }
        public Guid? DepartmentId { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
