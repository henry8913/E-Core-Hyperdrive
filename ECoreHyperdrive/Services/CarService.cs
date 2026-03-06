using ECoreHyperdrive.Models;

namespace ECoreHyperdrive.Services;

public class CarService
{
    public List<Supercar> GetInventory()
    {
        return new List<Supercar>
        {
            new Supercar { 
                Id = 1, 
                Brand = "McMurtry Automotive", 
                Model = "McMurtry Spéirling Pure", 
                ZeroToHundred = 1.4, 
                RangeKm = 26, 
                Price = 995000, 
                ImageUrl = "https://cdn.motor1.com/images/mgl/g4k2w4/s3/mcmurtry-speirling-pure.jpg" 
            },
            new Supercar { 
                Id = 2, 
                Brand = "Hispano Suiza", 
                Model = "Hispano Suiza Carmen Sagrera", 
                ZeroToHundred = 2.6, 
                RangeKm = 490, 
                Price = 3000000, 
                ImageUrl = "https://www.hispanosuizacars.com/assets/themes/hispano-suiza/_/img/tmp/carmen-sagrera-gallery/exterior/01_carmen_sagrera_exterior.jpg" 
            },
            new Supercar { 
                Id = 3, 
                Brand = "Ariel", 
                Model = "Ariel Hipercar", 
                ZeroToHundred = 2.09, 
                RangeKm = 240, 
                Price = 840000, 
                ImageUrl = "https://www.ansa.it/webimages/news_base/2022/9/2/196e6466c66cb078516b491b0063cabb.jpg" 
             },
                new Supercar { 
                    Id = 4, 
                    Brand = "BYD", 
                    Model = "BYD Yangwang U9", 
                    ZeroToHundred = 2.36, 
                    RangeKm = 460, 
                    Price = 400000, 
                    ImageUrl = "https://media.motorbox.com/image/byd-yangwang-u9-un-design-audace-e-super-affilato/8/1/0/810041/810041-16x9-lg.jpg" 
                }
        };
    }
}