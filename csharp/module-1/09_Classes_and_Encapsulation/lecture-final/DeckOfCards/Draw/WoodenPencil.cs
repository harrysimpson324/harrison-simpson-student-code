using System.Drawing;

/// <summary>
/// NAMESPACE DEFINITION
///
/// Uppercase and aligned with a module or general purpose it provides
/// Separated by Periods like TechElevator.Classes
/// </summary>
namespace Draw.Tool
{
	/// <summary>
	/// CLASS DECLARATION
	/// Naming convention: singular and PascalCase
	/// </summary>
	class WoodenPencil
	{
		/// <summary>
		/// CLASS VARIABLES AND PROPERTIES
		///
		/// Static modifier, or const (implicit static).
		/// May be public or private.
		/// Often const, but not required to be.
		///
		/// All wooden pencils have a "fixed" set of default values for length,
		///   shape, hardness, and color. External code should be able to ask
		///   WoodenPencil for these defaults.
		///
		/// All wooden pencils have a minimum length below which they are
		///   considered a "stub" and should be discarded.
		///
		/// All wooden pencils have a minimum sharpness below which they are
		///   too dull and need to be sharpened.
		///
		/// Note: These values belong to "ALL" wooden pencils, and thus
		///   belong to the class of WoodenPencil, hence the static modifier,
		///   explicitly written or implied by 'const'.
		/// </summary>
		public const double DefaultLength = 8.0;                    // default length
		public const int DefaultShape = 2;                          // default shape
		public const string DefaultHardness = "HB";                 // default hardness
		public static readonly Color DefaultColor = Color.Yellow;   // default color
		public const double DefaultStubLength = 2.0;                // default stubLength
		public const double DefaultMaxDullness = 0.3;               // default maxDullness

		// backing variable required for below variables in order to prevent being set to an invalid value
		private static double stubLength = DefaultStubLength;       // when pencil is considered a "stub", in inches
		public static double StubLength
		{
			get
			{
				return stubLength;      // Note use of the backing variable
			}
			set
			{
				if (value >= 0.0 && value <= DefaultLength) // stubLength must be between 0.0 and DefaultLength
				{

					stubLength = value; // Note use of the backing variable
				}
			}
		}

		private static double maxDullness = DefaultMaxDullness;     // when pencil needs sharpening (minimum sharpness)
		public static double MaxDullness
		{
			get
			{
				return maxDullness;			// Note use of the backing variable
			}
			set
			{
				if (value >= 0.0 && value <= 1.0)  // maxDullness must be between 0.0 and 1.0
				{
					maxDullness = value;    // Note use of the backing variable
				}
			}
		}


		/// <summary>
		/// PROPERTIES
		///
		/// Each instance of a wooden pencil has the following individual properties.
		///
		/// Note that Length and Sharpness are 'private set' since they are adjusted
		///   over time as the pencil writes and is sharpened,
		///   but shouldn't be settable from outside class.
		///
		/// They rest of the properties are set only once in the constructor, and have
		///   no set.
		/// </summary>
		public double Length { get; private set; }      // in inches
		public int Shape { get; }						// 1=triangular, 2=hexagonal, 3=round
		public string Hardness { get; }					// "B", "HB", "F", "H", "2H"
		public Color Exterior { get; }					// exterior color, not lead color
		public double Sharpness { get; private set; }   // min 0.0, max 1.0

        ///	Derived properties
        ///   return data type doesn't need to be same as the properties/variables it's derived from
        ///   typically starts with 'Is' if returning a boolean
        public bool IsStub
        {
            get
            {
                if (this.Length <= StubLength)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsSharp
        {
            get
            {
                if (this.Sharpness > maxDullness)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// CONSTRUCTORS
        ///
        /// Must match class name.
        /// Does not return anything, not even void
        ///
        /// Default constructor is the one that accepts no parameters.
        ///
        /// Note the use of `this()` to call overload constructor with default values.
        ///
        /// Fully-defined overload constructor allows arguments/values to be passed-in for
        ///   all properties.
        /// Note, all parameter values are validated to ensure consistent state.
        /// </summary>

        public WoodenPencil()
			// standard wooden pencils are assumed to be unsharpened when first instantiated (i.e. 0.0)
			: this(DefaultLength, DefaultShape, DefaultHardness, DefaultColor, 0.0)
		{
		}

		public WoodenPencil(double length, int shape, string hardness, Color color, double sharpness)
		{
			if (length >= 0.0 && length <= DefaultLength)
			{
				this.Length = length;
			}
			else
			{
				this.Length = DefaultLength;
			}
			if (shape >= 1 && shape <= 3)
			{
				this.Shape = shape;
			}
			else
			{
				this.Shape = DefaultShape;
			}
			if ((hardness == "B") || (hardness == "F") || (hardness == "H") || (hardness == "2H"))
			{
				this.Hardness = hardness;
			}
			else
			{
				this.Hardness = DefaultHardness;
			}
			if (color != null)
			{
				this.Exterior = color;
			}
			else
			{
				this.Exterior = DefaultColor;
			}
			if (sharpness >= 0.0 && sharpness <= 1.0)
			{
				this.Sharpness = sharpness;
			}
			else
			{
				this.Sharpness = 0.0;
			}
		}

		/// <summary>
		/// INSTANCE METHODS
		///
		/// Methods are named with verbs (i.e. GetSomething, CalculateSomething, DoSomething, AddSomething).
		/// All methods that return a value have a 'return' statement.
		/// Must return the type defined in the method signature.
		/// </summary>

		public bool Write()
		{
			// Calls overload 'write(double)` assuming 0.25 writing wear on sharpness.
			return Write(0.25);
		}

		public bool Write(double writingWear)
		{
			// Checks sharpness of pencil to confirm it's not too dull to write.
			if (this.Sharpness > maxDullness)
			{
				// OK to write, apply writingWear to sharpness
				double newSharpness = Sharpness - writingWear;
				if (newSharpness >= 0)
				{
					this.Sharpness = newSharpness;
				}
				else
				{
					this.Sharpness = 0.0; // writing session wore away all sharpness
				}
				return true;
			}
			else
			{
				return false;			 // No writing took place, too dull
			}
		}

		public bool Sharpen()
		{
			// Sharpening restores sharpness to 1.0, and removes 0.25 from the length of the pencil.
			double newLength = this.Length - 0.25;
			if (newLength >= StubLength && newLength >= 0.0)
			{
				// OK to sharpen pencil
				this.Sharpness = 1.0;
				this.Length = newLength;
				return true;
			}
			else
			{
				return false;			// Pencil not sharpened, not long enough
			}
		}


		/// <summary>
		/// STATIC METHODS
		///
		/// Static methods belong to the class, an "instance" isn't required to use them.
		/// Static methods can't access instance members (e.g. properties or methods).
		/// Static methods are good for utility functions that aren't dependent on instance variables.
		/// </summary>
		public static double ClayPercentage(string hardness)
		{
			// The hardness of a pencil is dependent upon the percentage of clay mixed
			//   with the graphite. The higher the clay content, the harder the pencil.
			//
			// The following percentages are fictitious as actual clay to graphite percentages are trade secrets.
			if (hardness == "B")
			{
				return 15.0;
			}
			else if (hardness == "HB")
			{
				return 20.0;
			}
			else if (hardness == "F")
			{
				return 25.0;
			}
			else if (hardness == "H")
			{
				return 30.0;
			}
			else if (hardness == "2H")
			{
				return 35.0;
			}
			else
			{
				// hardness not valid
				return -1.0;
			}
		}
    }
}
