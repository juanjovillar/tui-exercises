using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public abstract class FileTypeManager
    {
        public abstract bool CanManageType(string filetype);
    }
}
