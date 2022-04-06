using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PlannerCodeDTO
    {
        private int id;
        private string factory_code;
        private string production_line;
        private string planner_code;
        private string updated_by;
        private DateTime updated_date;

        // id
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        // factory_code
        public string FactoryCode
        {
            get
            {
                return factory_code;
            }

            set
            {
                factory_code = value;
            }
        }

        // production_line
        public string ProductionLine
        {
            get
            {
                return production_line;
            }

            set
            {
                production_line = value;
            }
        }

        // planner_code
        public string PlannerCode
        {
            get
            {
                return planner_code;
            }

            set
            {
                planner_code = value;
            }
        }

        // updated_by
        public string UpdatedBy
        {
            get
            {
                return updated_by;
            }

            set
            {
                updated_by = value;
            }
        }

        // updated_date
        public DateTime UpdatedDate
        {
            get
            {
                return updated_date;
            }

            set
            {
                updated_date = value;
            }
        }

        // PlannerCodeDTO
        public PlannerCodeDTO()
        {

        }

    }
}
