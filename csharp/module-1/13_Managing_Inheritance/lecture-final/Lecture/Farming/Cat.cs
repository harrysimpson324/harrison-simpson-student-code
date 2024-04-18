namespace Lecture.Farming
{
    public class Cat : FarmAnimal
    {
        public Cat() : base("Cat", "meow")
        {
        }

        public override string Eat()
        {
            return "Eating cat food...";
        }

        // once FarmAnimal.Sound virtual declaration is removed, you can't override it
        //public override string Sound
        //{
        //    get
        //    {
        //        return "Meow";
        //    }
        //}
    }
}
