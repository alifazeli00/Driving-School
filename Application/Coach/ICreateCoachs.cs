using Application.Context;
using Application.Dtos;
using Domain.Coach;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coach
{
    //Sabt Morabi
    public interface ICreateCoachs
    {

        BaseDto<int> Add(AddDto Req);
         BaseDto<GetDto> Get();
       // List<GetDto> Get();
        BaseDto<GetDto> GetById(int Id);
        BaseDto Edit(EditDto Req);
        BaseDto Remove(int Id);




    }
    public class CreateCoachs : ICreateCoachs
    {
        private readonly IDataBaceContext context;
        public CreateCoachs(IDataBaceContext context)
        {
            this.context = context;
                
        }
        public BaseDto<int> Add(AddDto Req)
        {

            //Users xxx = new Users()
            //{
            //    Family = "fazel",
            //    CodeMeli = 1234,
            //    Name = "rez",


            //};
            //Users xx = new Users()
            //{
            //    Family = "najafi",
            //    CodeMeli = 5678,
            //    Name = "mamd",


            //};
            //context.Users.Add(xxx);
            //context.Users.Add(xx);
            //context.SaveChanges();



            Coachs x = new Coachs()
            {

                Name = Req.Name,
                Image = new Image() { Src = Req.Image.Src },

            };
            context.Coachs.Add(x);context.SaveChanges();
            return new BaseDto<int> { IsSuccess = true, Messeges = "SabtShod", Exist=x.Id};

        }

        public BaseDto Edit(EditDto Req)
        {
           var res=context.Coachs.Where(p=>p.Id == Req.Id).FirstOrDefault();
            res.Name=Req.Name;
      
            context.SaveChanges();
          
       //     res.Image = new Image() { Src=Req.Image.Src };


            return new BaseDto { IsSuccess = true, Messeges = "TaghirYaft" };
        }

        public BaseDto<GetDto> Get()
        {

           
           var res = context.Coachs.Select(p=> new GetDto
            {
                Id=p.Id,
                Name=p.Name,
         //       Image= new ImageDto { Src=p.Image.Src }
                 

            }).ToList();
           
            return new BaseDto<GetDto>
            {

                IsSuccess = true,
                Messeges = "",
                Deta = res
            };


        }

        public BaseDto<GetDto> GetById(int Id)
        {
            var res = context.Coachs.Where(p => p.Id == Id).Select(p => new GetDto
            {
                Id = p.Id,
                Name = p.Name,
                //  Image = new ImageDto { Src = p.Image.Src }


            });

            return new BaseDto<GetDto>
            {
                IsSuccess = true,
                Messeges = "",
                Deta = res
            };
            
        }

        public BaseDto Remove(int Id)
        {
           var res= context.Coachs.FirstOrDefault(p => p.Id == Id);
            res.IsRemoved = true;
            context.SaveChanges();
            return new BaseDto { IsSuccess = true, Messeges = "HazfShod" };
        }
    }

    public class AddDto
    {
    
        public string Name { get; set; } 
    
        public ImageDto Image { get; set; }
    



    }
    public class ImageDto
    {
        public string Src { get; set; }
       // public Coachs Coachs { get; set; }
        //public int CatalogItemsId { get; set; }
    }
    public class UsersDto
    {

        public string Name { get; set; }
        public string Family { get; set; }
        public int CodeMeli { get; set; }

    }


    public class GetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    //    public int ImageId { get; set; }
        public ImageDto Image { get; set; }
      //  public ICollection<UsersDto> Users { get; set; }

    }
    public class EditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public ImageDto Image { get; set; }
   //     public ICollection<UsersDto> Users { get; set; }


    }
}
