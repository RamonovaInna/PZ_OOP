

namespace Web_Service.Models
{
    public class AreaInfo
    {
        public int Id { get; set; }

        public string DepartamentalAffiliation { get; set; }

        public string AdmArea { get; set; }

        public string District { get; set; }

        public string Location { get; set; }

        public string DogParkArea { get; set; }

        public string Lighting { get; set; }

        public string Fencing { get; set; }

        public System.Collections.Generic.List<WorkingHours> WorkingHours { get; set; } = new System.Collections.Generic.List<WorkingHours>();

    }
}