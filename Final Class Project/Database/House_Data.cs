using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Class_Project.Database
{
    class House_Data
    {
        public static List<House> get_house(string where_key = "1", string where_value = "1")
        {
            var entity = new remax_Entities();

            var query = entity.Database.SqlQuery<House>(string.Format(@"select * from Houses where {0} = '{1}'", where_key, where_value));


            return query.ToList<House>();
        }

        public static bool Save_house(House house)
        {
            var entity = new remax_Entities();

            entity.Houses.Add(house);
            
            entity.SaveChanges();

            return true;
        }

        public static House find(int id)
        {
            var entity = new remax_Entities();
            House h = entity.Houses.Find(id);

            return h;
        }

        public static bool delete(int id)
        {
            var entity = new remax_Entities();
            House h = entity.Houses.Find(id);

            if (h != null)
            {
                entity.Houses.Remove(h);
                entity.SaveChanges();

                return true;
            }

            return false;
        }

        public static bool update_house(House house)
        {
            var entity = new remax_Entities();

            House h = entity.Houses.Find(house.id);

            if (h != null)
            {
                h.house_number = house.house_number;
                h.number_of_bathrooms = house.number_of_bathrooms;
                h.number_of_rooms = house.number_of_rooms;
                h.pool = house.pool;
                h.fireplace = house.fireplace;
                h.garage = house.garage;
                h.city = house.city;
                h.state = house.state;
                h.country = house.country;
                h.price = house.price;
                h.street_name = house.street_name;
                entity.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public static List<city> get_cities()
        {
            var entity = new remax_Entities();
            var query = (from c in entity.cities
                         select c);

            return query.ToList<city>();
        }

        public static List<state> get_states()
        {
            var entity = new remax_Entities();
            var query = (from c in entity.states
                         select c);

            return query.ToList<state>();
        }

        public static List<country> get_countries()
        {
            var entity = new remax_Entities();
            var query = (from c in entity.countries
                         select c);

            return query.ToList<country>();
        }


        //public static List<House> get_house(string where_key = "1", string where_value = "1")
        //{
        //    return House_Data.get_house(where_key, where_value);
        //}

        //public static bool Save_house(House house)
        //{
        //    return House_Data.Save_house(house);
        //}

        //public static List<city> get_cities()
        //{
        //    return House_Data.get_cities();
        //}

        //public static List<state> get_states()
        //{
        //    return House_Data.get_states();
        //}

        //public static List<country> get_countries()
        //{
        //    return House_Data.get_countries();
        //}
    }
}
