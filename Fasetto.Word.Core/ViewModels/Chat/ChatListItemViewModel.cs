using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// ViewModel for each chat list item in the overrview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string  Message { get; set; }

        /// <summary>
        /// The initials inside the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values for the background color of the profile picture
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages in the chat
        /// </summary>
        public bool IsNewContentAvailable { get; set; }

        public bool IsSelected { get; set; }
    }
}
