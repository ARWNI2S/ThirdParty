﻿using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using System;
using System.Threading.Tasks;

namespace OWSCharacterPersistence.Requests.Abilities
{
    /// <summary>
    /// Add Ability To Character
    /// </summary>
    /// <remarks>
    /// Adds an Ability to a Character and also sets the initial values of Ability Level and the per instance Custom JSON
    /// </remarks>
    public class AddAbilityToCharacterRequest
    {
        /// <summary>
        /// Ability Name
        /// </summary>
        /// <remarks>
        /// This is the name of the ability to add to the character.
        /// </remarks>
        public string AbilityName { get; set; }
        /// <summary>
        /// Ability Level
        /// </summary>
        /// <remarks>
        /// This is a number representing the Ability Level of the ability to add.  If you need more per instance customization, use the Custom JSON field.
        /// </remarks>
        public int AbilityLevel { get; set; }
        /// <summary>
        /// Character Name
        /// </summary>
        /// <remarks>
        /// This is the name of the character to add the ability to.
        /// </remarks>
        public string CharacterName { get; set; }
        /// <summary>
        /// Custom JSON
        /// </summary>
        /// <remarks>
        /// This field is used to store Custom JSON for the specific instance of this Ability.  If you have a system where each ability on a character has some kind of custom variation, then this is where to store that variation data.  In a system where an ability operates the same on every player, this field would not be used.  Don't store Ability Level in this field, as there is already a field for that.  If you need to store Custom JSON for ALL instances of an ability, use the Custom JSON on the Ability itself.
        /// </remarks>
        public string CharHasAbilitiesCustomJSON { get; set; }

        private SuccessAndErrorMessage output;
        private Guid customerGUID;
        private ICharactersRepository charactersRepository;

        public void SetData(ICharactersRepository charactersRepository, IHeaderCustomerGUID customerGuid)
        {
            this.charactersRepository = charactersRepository;
            customerGUID = customerGuid.CustomerGUID;
        }

        public async Task<SuccessAndErrorMessage> Handle()
        {
            output = new SuccessAndErrorMessage();
            await charactersRepository.AddAbilityToCharacter(customerGUID, AbilityName, CharacterName, AbilityLevel, CharHasAbilitiesCustomJSON);

            output.Success = true;
            output.ErrorMessage = "";

            return output;
        }
    }
}
