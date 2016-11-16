using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class SinInstructorException:Exception
    {
        public SinInstructorException()
            : base("Sin Instructor")
        {

        }
    }
}
