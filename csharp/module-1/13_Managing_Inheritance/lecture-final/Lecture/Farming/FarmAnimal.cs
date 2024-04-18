namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        private string sound;
        /// <summary>
        /// The farm animal's sound.
        /// </summary>
        public string Sound
        {
            get
            {
                if (IsAsleep)
                {
                    return "Zzzzz....";
                }
                return sound;
            }
            set
            {
                sound = value;
            }
        }

        /// <summary>
        /// Indicates if the farm animal is asleep.
        /// </summary>
        public bool IsAsleep { get; private set; }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// <param name="sound">The sound that the animal makes.</param>
        public FarmAnimal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public abstract string Eat();

        public void Sleep(bool isAsleep)
        {
            IsAsleep = isAsleep;
        }
    }
}
