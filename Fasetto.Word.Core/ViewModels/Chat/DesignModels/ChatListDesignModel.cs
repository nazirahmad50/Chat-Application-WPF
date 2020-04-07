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
    public class ChatListDesignModel : ChatListViewModel
    {
        /// <summary>
        /// Singleton
        /// Also its static so we can bind to it in XAML
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                 new ChatListItemViewModel
                 {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat is great",
                    ProfilePictureRGB = "3099c5",
                    IsNewContentAvailable = true
                },
                   new ChatListItemViewModel
                 {
                    Initials = "DD",
                    Name = "Dave",
                    Message = "What a great chat app",
                    ProfilePictureRGB = "fe4503",
                },
                     new ChatListItemViewModel
                 {
                    Initials = "SM",
                    Name = "Sam",
                    Message = "This best chat app ever",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true
                },
                    new ChatListItemViewModel
                 {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat is great",
                    ProfilePictureRGB = "3099c5",
                },
                   new ChatListItemViewModel
                 {
                    Initials = "DD",
                    Name = "Dave",
                    Message = "What a great chat app",
                    ProfilePictureRGB = "fe4503",
                },
                     new ChatListItemViewModel
                 {
                    Initials = "SM",
                    Name = "Sam",
                    Message = "This best chat app ever",
                    ProfilePictureRGB = "00d405",
                },
                         new ChatListItemViewModel
                 {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat is great",
                    ProfilePictureRGB = "3099c5",
                },
                   new ChatListItemViewModel
                 {
                    Initials = "DD",
                    Name = "Dave",
                    Message = "What a great chat app",
                    ProfilePictureRGB = "fe4503",
                },
                     new ChatListItemViewModel
                 {
                    Initials = "SM",
                    Name = "Sam",
                    Message = "This best chat app ever",
                    ProfilePictureRGB = "00d405",
                }


         };
        }
    }
}
