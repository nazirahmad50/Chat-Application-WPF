using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel: ChatListItemViewModel
    {
        /// <summary>
        /// Singleton
        /// Also its static so we can bind to it in XAML
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel(); 

        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This chat is great";
            ProfilePictureRGB = "3099c5";
        }
    }
}
