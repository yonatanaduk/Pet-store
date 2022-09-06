using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{


    public class AnimalsContext : DbContext
    {

        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }


        public virtual DbSet<Category>? categories { get; set; }
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sources = new string[]
                   {
                "https://www.computerhope.com/jargon/e/error.png",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Lion_waiting_in_Namibia.jpg/800px-Lion_waiting_in_Namibia.jpg",
                "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/golden-retriever-royalty-free-image-506756303-1560962726.jpg",
                "https://www.birdlife.org/wp-content/uploads/2021/06/Eagle-in-flight-Richard-Lee-Unsplash-1-edited-scaled.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/White_shark.jpg/800px-White_shark.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/Cat03.jpg/330px-Cat03.jpg",
                "https://cdn.britannica.com/05/203605-050-59F5FB39/chameleon-on-branch.jpg",
                "https://www.imf.org/-/media/Images/IMF/FANDD/article-image/2019/December/chami-index.ashx",
                "http://www.dvarhamefarsem.co.il/Hot/20710/Rashit.JPG",
                "https://whnt.com/wp-content/uploads/sites/20/2022/05/GettyImages-1171368832.jpg?w=960&h=540&crop=1",
                "https://img.apmcdn.org/9fe734b0a7596f13b98ccd5152262fe7d590ce4d/widescreen/a6c353-20220405-screech-owl-1000.jpg",
                   };

            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Birds" },
                new { CategoryId = 3, Name = "Fish" },
                new { CategoryId = 4, Name = "Amphibians" },
                new { CategoryId = 5, Name = "reptiles" }
                );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, CategoryId = 1, Age = 5, Name = "Lion", PictureSrc = sources[1], Description = "The world's most social felines, lions roam the savannas and grasslands of the African continent, hunting cooperatively and raising cubs in prides. Online visitors can catch a glimpse of the Smithsonian's National Zoo's lions on the" },
                new Animal { AnimalId = 2, CategoryId = 1, Age = 2, Name = "Dog", PictureSrc = sources[2], Description = "The dog is a pet animal. A dog has sharp teeth so that it can eat flesh very easily, it has four legs, two ears, two eyes, a tail, a mouth, and a nose. It is a very clever animal and is very useful in catching thieves. It runs very fast, barks loudly and attacks the strangers. A dog saves the life of the master from danger. One can find dogs everywhere in the world. Dogs are a very faithful animal. It has a sharp mind and a strong sense of hearing smelling the things. It also has many qualities like swimming in the water, jumping from anywhere, good smelling sense." },
                new Animal { AnimalId = 3, CategoryId = 2, Age = 12, Name = "Eagle", PictureSrc = sources[3], Description = "The Golden Eagle is one of the largest, fastest, nimblest raptors in North America. Lustrous gold feathers gleam on the back of its head and neck; a powerful beak and talons advertise its hunting prowess. You're most likely to see this eagle in western North America, soaring on steady wings or diving in pursuit of the jackrabbits and other small mammals that are its main prey. Sometimes seen attacking large mammals, or fighting off coyotes or bears in defense of its prey and young, the Golden Eagle has long inspired both reverence and fear." },
                new Animal { AnimalId = 4, CategoryId = 3, Age = 3, Name = "Shark", PictureSrc = sources[4], Description = "Like other fishes, sharks are cold-blooded, have fins, live in the water, and breathe with gills. A shark's skeleton is made of cartilage. A shark's fusiform (rounded and tapering at both ends) body shape reduces drag and requires minimum energy to swim. Sharks eat far less than most people imagine." },
                new Animal { AnimalId = 5, CategoryId = 1, Age = 4, Name = "Cat", PictureSrc = sources[5], Description = "There are many different breeds of cats, including Abyssinian, Himalayan, Maine Coon, Manx, Persian, Scottish Fold, and Siamese, to name a few. The Cat Fanciers’ Association, which is the world’s largest registry of pedigreed cats, recognizes about 40 distinct breeds. The most familiar cats are the domestic shorthair and the domestic longhair, which are really mixtures of different breeds. Cat breeds differ in looks, coat length, and other characteristics but vary relatively little in size. On average, only 5 to 10 pounds separate the smallest and largest domestic breeds of cats." },
                new Animal { AnimalId = 6, CategoryId = 5, Age = 1, Name = "Chameleon", PictureSrc = sources[6], Description = "They have crests or horns on the backs of their skulls, long, sticky tongues, and uniquely-shaped feet. Many chameleon species also have a prehensile tail, which can be wrapped around branches to aid them in climbing. The scales of many species can change color to green, gray, yellow, red, purple, blue, and more." },
                new Animal { AnimalId = 7, CategoryId = 3, Age = 15, Name = "Whale", PictureSrc = sources[7], Description = "Whales are the largest animals on Earth and they live in every ocean. The massive mammals range from the 600-pound dwarf sperm whale to the colossal blue whale, which can weigh more than 200 tons and stretch up to 100 feet long—almost as long as a professional basketball court." },
                new Animal { AnimalId = 8, CategoryId = 2, Age = 2, Name = "Pigeon", PictureSrc = sources[8], Description = "Pigeons are gentle, plump, small-billed birds with a skin saddle (cere) between the bill and forehead. All pigeons strut about with a characteristic bobbing of the head. Because of their long wings and powerful flight muscles, they are strong, swift fliers." },
                new Animal { AnimalId = 9, CategoryId = 5, Age = 4, Name = "Alligator", PictureSrc = sources[9], Description = "Alligators have a long, rounded snout that has upward facing nostrils at the end; this allows breathing to occur while the rest of the body is underwater. The young have bright yellow stripes on the tail; adults have dark stripes on the tail. It's easy to distinguish an alligator from a crocodile by the teeth." },
                new Animal { AnimalId = 10, CategoryId = 2, Age = 9, Name = "Owl", PictureSrc = sources[10], Description = "Owls have round, forward-looking eyes, a sharply hooked beak, and acute hearing and vision. They are 5–28 in. (13–70 cm) long. The feathers of some species form a disk framing the face or ear tufts that help locate prey by reflecting sound to the ears." }
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1, Content = "king of animals" },
                new { CommentId = 2, AnimalId = 2, Content = "the man's best friend" },
                new { CommentId = 3, AnimalId = 1, Content = "Simba is his brother" },
                new { CommentId = 4, AnimalId = 5, Content = "licks itself" },
                new { CommentId = 5, AnimalId = 6, Content = "can change colors" },
                new { CommentId = 6, AnimalId = 7, Content = "the biggest fish in the world" },
                new { CommentId = 7, AnimalId = 9, Content = "you don't want to mess with this guy..." },
                new { CommentId = 8, AnimalId = 10, Content = "the smartest bird" }
                );


            modelBuilder.Entity<Admin>().HasData(
                new { UserName = "abc", Password = "123" }
                );
                
        }
    }
}
