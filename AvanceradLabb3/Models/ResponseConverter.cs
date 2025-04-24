using AvanceradLabb3.Models.DTO;

namespace AvanceradLabb3.Models
{
    public static class ResponseConverter
    {


        public static Person ToPerson(AddPersonReq request)
        {
            Person person = new Person();

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.Age = request.Age;

            return person;
        }

        public static ICollection<GetPersonRes> ToPersonList(ICollection<Person> request)
        {
            ICollection<GetPersonRes> result = new HashSet<GetPersonRes>();

            foreach (var person in request)
            {
                result.Add(new GetPersonRes
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Age = person.Age,
                    Interests = ToInterestList(person.Interests)
                });
            }

            return result;
        }

        public static ICollection<AddInterestReq> ToInterestList(ICollection<Interest> request)
        {
            ICollection<AddInterestReq> result = new HashSet<AddInterestReq>();
            foreach (var interest in request)
            {
                result.Add(new AddInterestReq
                {
                    Title = interest.Title,
                    Description = interest.Description
                });
            }

            return result;

        }

    }
}
