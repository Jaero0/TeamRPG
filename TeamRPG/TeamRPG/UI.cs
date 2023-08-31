using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeamRPG
{
    //------문현우 UI 구현 메서드----------
    public class UI
    {
        public static void DisplayGameUI()
        {
            Console.SetWindowSize(80, 35);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("│                                                                             │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────┘");
        }

        public static void DIsplayGameTitle()
        {
            Console.SetCursorPosition(8, 7);
            Console.WriteLine("###### ######     #     ####   ####   ######   ######    ### # ");
            Console.SetCursorPosition(8, 8);
            Console.WriteLine("# ## #  ##  #    ###     ###   ###     ##  ##   ##  ##  #   ## ");
            Console.SetCursorPosition(8, 9);
            Console.WriteLine("# ## #  ## #     ###     # ## # ##     ##  ##   ##  ## ##    # ");
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("  ##    ####    #  ##    # ## # ##     ##  #    ##  ## ##      ");
            Console.SetCursorPosition(8, 11);
            Console.WriteLine("  ##    ## #    #  ##    # ## # ##     #####    #####  ##  ### ");
            Console.SetCursorPosition(8, 12);
            Console.WriteLine("  ##    ##  #  #######   #  ##  ##     ##  ##   ##     ##   ## ");
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("  ##    ##  #  #    ##   #  ##  ##     ##  ##   ##      #   ## ");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine(" ####  ###### ###  #### ### ## ####   #### ### ####      ### # ");
        }
    }
}
