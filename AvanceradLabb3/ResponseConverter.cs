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

        public static AddPersonReq ToPersonReq(Person request)
        {
            AddPersonReq person = new AddPersonReq
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Age = (int)request.Age
            };
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
                    Interests = ToInterestList(person.Interests),
                    Links = ToLinkList(person.Links)
                });
            }

            return result;
        }

        public static ICollection<InterestDTO> ToInterestList(ICollection<Interest> request)
        {
            ICollection<InterestDTO> result = new HashSet<InterestDTO>();
            foreach (var interest in request)
            {
                result.Add(new InterestDTO
                {
                    Title = interest.Title,
                    Description = interest.Description
                });
            }

            return result;

        }

        public static ICollection<LinkDTO> ToLinkList(ICollection<Hyperlink> request)
        {
            ICollection<LinkDTO> result = new HashSet<LinkDTO>();

            foreach(var link in request)
            {
                result.Add(new LinkDTO
                {
                    Title = link.Title,
                    Url = link.Url
                });
            }

            return result;
        }

    }
}
