using Common;
using Data;
using System;

namespace Factory
{
    public class Factory
    {
        public static IFileDA GetFileDA() {
            return new FileDA();
        }
    }
}
