﻿using OWSShared.Interfaces;

namespace OWSShared.Implementations
{
    public class DefaultCustomCharacterDataSelector : ICustomCharacterDataSelector
    {
        public bool ShouldExportThisCustomCharacterDataField(string fieldName)
        {
            if (fieldName == "CosmeticCharacterData")
            {
                return true;
            }

            return false;
        }
    }
}
