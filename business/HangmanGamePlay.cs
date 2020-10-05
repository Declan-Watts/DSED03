using Android.Widget;
using DSED03.business;
using DSED03.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSED03
{
    public class HangmanGamePlay
    {
        public TextView displayedWord { get; set; }
        public TextView message { get; set; }
        public int incorrectGuesses;
        private int score;
        private int gueses;
        private string word;
        #region Words Array
        private string[] words = new string[] { "year", "report", "stuff", "jittery", "absent", "private", "oranges", "morning", "third", "useless", "bare", "office", "wrong", "expert", "instrument", "acoustics", "smile", "bag", "uncovered", "statuesque", "ajar", "loaf", "giants", "bait", "admit", "advertisement", "program", "competition", "building", "economic", "crooked", "vivacious", "cynical", "same", "form", "aunt", "scatter", "ablaze", "prickly", "bottle", "carriage", "staking", "ski", "manage", "top", "food", "adaptable", "wrathful", "popcorn", "fancy", "icy", "scare", "dysfunctional", "deeply", "comparison", "solid", "pathetic", "inject", "peel", "pump", "earthquake", "clammy", "multiply", "cactus", "arrive", "aboard", "island", "spoil", "disappear", "unwieldy", "supply", "defective", "zoom", "smelly", "truthful", "language", "elastic", "yummy", "goofy", "receive", "summer", "curl", "mass", "string", "protest", "male", "hope", "spare", "found", "numerous", "cub", "belligerent", "functional", "sore", "rings", "x-ray", "subtract", "furtive", "cook", "pocket", "oceanic", "languid", "wealthy", "mountain", "dad", "nippy", "laborer", "many", "crayon", "ignore", "terrify", "unused", "caption", "fool", "opposite", "cup", "jam", "grandiose", "move", "fowl", "increase", "panicky", "apathetic", "weak", "kind", "nutty", "slippery", "tickle", "night", "helpless", "cats", "lumpy", "entertaining", "humdrum", "curvy", "calendar", "degree", "drain", "stroke", "damaged", "skin", "steer", "reply", "feigned", "aberrant", "answer", "suit", "expansion", "snow", "intend", "disarm", "cherries", "behavior", "nimble", "labored", "rough", "bed", "known", "harm", "dream", "sassy", "carry", "steadfast", "irritating", "houses", "understood", "divergent", "heady", "wrestle", "clean", "song", "enormous", "grandmother", "toothbrush", "sign", "guarantee", "quaint", "swing", "irritate", "crowd", "present", "bell", "whirl", "prick", "plausible", "giant", "girl", "plane", "grotesque", "post", "well-to-do", "ship", "trucks", "lamp", "cake", "flippant", "knowledge", "toes", "borrow", "recognise", "health", "division", "nod", "blade", "fold", "governor", "field", "merciful", "tidy", "examine", "feeling", "float", "exciting", "wild", "linen", "secretive", "fresh", "direful", "devilish", "garrulous", "coat", "copy", "cough", "phobic", "scary", "drunk", "eggs", "baseball", "rinse", "flower", "growth", "quirky", "paint", "poor", "twig", "thumb", "stone", "scarf", "sound", "mint", "first", "surprise", "consider", "diligent", "march", "excite", "nifty", "toys", "magnificent", "vacation", "tangible", "stimulating", "iron", "middle", "breath", "parallel", "zinc", "overwrought", "skip", "crow", "futuristic", "committee", "rely", "note", "sleep", "improve", "womanly", "fast", "basketball", "nut", "imagine", "edge", "guide", "relation", "guard", "example", "natural", "vein", "handy", "queen", "typical", "super", "stingy", "spark", "abrasive", "nosy", "identify", "hot", "brake", "arrange", "attempt", "art", "skate", "stale", "drab", "narrow", "distribution", "roof", "tame", "pray", "alike", "quack", "sweet", "applaud", "kettle", "lamentable", "clover", "wind", "sniff", "possess", "club", "plain", "yell", "right", "follow", "fact", "fearless", "halting", "stretch", "shock", "cracker", "numberless", "picture", "rose", "voyage", "suggest", "steep", "writer", "elated", "blot", "girls", "juggle", "possessive", "zip", "miss", "pin", "husky", "haunt", "close", "stereotyped", "guiltless", "driving", "ready", "walk", "shop", "expensive", "subdued", "zany", "money", "blush", "lick", "hideous", "well-off", "quarter", "ill-informed", "toad", "man", "gaze", "interest", "title", "boil", "flagrant", "available", "tray", "berry", "zebra", "crown", "wing", "amount", "dynamic", "long", "pointless", "fear", "mellow", "key", "war", "absorbing", "rub", "snatch", "harbor", "promise", "serious", "gray", "gaudy", "thin", "peaceful", "tow", "camera", "measly", "spooky", "color", "little", "books", "dashing", "famous", "obscene", "odd", "vanish", "quixotic", "fair", "highfalutin", "youthful", "spurious", "outstanding", "pleasant", "zoo", "rotten", "fog", "cheat", "harmonious", "unable", "possible", "oval", "steel", "label", "helpful", "female", "poised", "utopian", "jazzy", "pause", "calculating", "cooperative", "aboriginal", "painstaking", "bore", "friends", "haircut", "accept", "risk", "exchange", "afraid", "abortive", "gorgeous", "obtainable", "melodic", "five", "melt", "tick", "vulgar", "locket", "pleasure", "marked", "voiceless", "billowy", "married", "shoe", "meddle", "purple", "rustic", "lettuce", "actor", "imaginary", "scene", "light", "humor", "root", "macabre", "green", "tin", "fry", "safe", "pie", "excellent", "pop", "remarkable", "obey", "misty", "compete", "ambiguous", "difficult", "jumbled", "birds", "payment", "educated", "curve", "mug", "soap", "blind", "team", "angle", "yawn", "range", "connect", "moan", "stir", "remember", "obtain", "flimsy", "farm", "annoy", "mixed", "whispering", "touch", "railway", "grain", "destroy", "zesty", "maid", "jelly", "cap", "furry", "meek", "servant", "black", "monkey", "clumsy", "squash", "pet", "old-fashioned", "tease", "system", "venomous", "superb", "press", "colorful", "joyous", "cultured", "hard-to-find", "chicken", "wicked", "alive", "delicate", "momentous", "sisters", "slip", "comb", "enter", "tiger", "chew", "itch", "hall", "relieved", "regret", "disillusioned", "axiomatic", "nail", "rifle", "sneaky", "unwritten", "boiling", "spy", "reduce", "station", "repair", "sweater", "debt", "tired", "hop", "number", "thoughtful", "bump", "stranger", "combative", "attraction", "infamous", "heavenly", "desert", "exuberant", "quartz", "country", "radiate", "dapper", "wide-eyed", "muscle", "mate", "empty", "shave", "grubby", "cellar", "position", "wakeful", "romantic", "license", "collar", "grandfather", "domineering", "excited", "spicy", "son", "zonked", "live", "unnatural", "wobble", "clap", "fasten", "finger", "impress", "fanatical", "delight", "coordinated", "sleet", "profit", "kneel", "holistic", "striped", "literate", "simplistic", "umbrella", "crush", "claim", "drown", "scientific", "open", "squealing", "enthusiastic", "mouth", "woebegone", "force", "hurried", "channel", "outrageous", "boring", "thunder", "political", "dependent", "uninterested", "belief", "race", "fix", "early", "cover", "observe", "painful", "workable", "unsuitable", "arrogant", "juvenile", "moon", "shake", "learn", "cuddly", "tip", "describe", "hammer", "squirrel", "fluffy", "inconclusive", "aback", "slave", "kindhearted", "windy", "window", "dangerous", "tub", "annoying", "mammoth", "strange", "cheap", "offer", "nine", "pig", "boy", "delightful", "rescue", "fax", "luxuriant", "volcano", "remain", "untidy", "stop", "stem", "spring", "tacky", "neat", "actually", "lonely", "unkempt", "minister", "nose", "preach", "homeless", "chin", "vigorous", "geese", "sort", "smoggy", "fail", "plough", "malicious", "earthy", "graceful", "mitten", "knife", "interrupt", "meeting", "bite", "tire", "bewildered", "action", "death", "aftermath", "milky", "border", "disgusted", "truculent", "testy", "army", "selfish", "quarrelsome", "mist", "carve", "blue-eyed", "violet", "rail", "deer", "stick", "snail", "organic", "pets", "agreeable", "rapid", "desire", "marry", "friendly", "income", "grass", "flood", "burly", "suspend", "nutritious", "heap", "calm", "flawless", "utter", "dog", "pretty", "great", "violent", "experience", "efficient", "bike", "sin", "rightful", "event", "cave", "purpose", "dance", "airplane", "chilly", "quiver", "awesome", "scarecrow", "squeak", "thick", "knit", "befitting", "silk", "skirt", "mean", "recondite", "unruly", "complex", "legal", "elfin", "honorable", "size", "group", "wave", "brave", "savory", "paste", "perfect", "cause", "copper", "peck", "pretend", "waves", "stamp", "needy", "tedious", "wilderness", "invincible", "flap", "grab", "tense", "tramp", "influence", "wise", "elderly", "statement", "shiny", "list", "ball", "seat", "interesting", "wanting", "tender", "beam", "jar", "bathe", "brief", "grin", "bubble", "burn", "lucky", "metal", "toe", "healthy", "expect", "concerned", "nation", "cycle", "noiseless", "needless", "wiry", "government", "defiant", "quince", "canvas", "living", "deranged", "greasy", "toy", "apologise", "jump", "brawny", "approval", "throat", "slap", "embarrassed", "concentrate", "rampant", "order", "draconian", "bumpy", "hapless", "kaput", "include", "feeble", "share", "boorish", "succinct", "curly", "overflow", "thing", "uppity", "reading", "murder", "innocent", "magic", "muddled", "expand", "acid", "celery", "hill", "flowery", "wrench", "cure", "handsomely", "swanky", "occur", "wacky", "deadpan", "tiresome", "cable", "trouble", "ugliest", "premium", "wistful", "hellish", "brush", "used", "fat", "adventurous", "kittens", "lighten", "vague", "pan", "berserk", "greedy", "star", "poison", "delay", "drum", "quilt", "chickens", "faithful", "wasteful", "impartial", "important", "afternoon", "peace", "unique", "slow", "point", "bee", "hover", "steady", "minute", "obsequious", "bouncy", "abstracted", "longing", "wonder", "nondescript", "black-and-white", "level", "double", "waggish", "refuse", "partner", "mice", "animal", "spill", "dreary", "null", "side", "wet", "chemical", "control", "grieving", "left", "hulking", "doubtful", "small", "stage", "nappy", "sour", "communicate", "lethal", "saw", "mute", "month", "development", "scream", "letter", "drag", "silly", "jail", "busy", "three", "file", "overjoyed", "paltry", "bat", "fairies", "reflect", "needle", "visitor", "stupendous", "second", "questionable", "amuck", "filthy", "burst", "tempt", "hand", "extra-large", "flow", "spiky", "wander", "far", "knowledgeable", "cooing", "snakes", "balance", "flaky", "ten", "letters", "beautiful", "seed", "mom", "useful", "thankful", "sedate", "dam", "abusive", "daily", "bang", "fruit", "demonic", "rainstorm", "enchanting", "rest", "trail", "brash", "woozy", "aware", "practise", "instruct", "circle", "shy", "overconfident", "careful", "wine", "weight", "turn", "discover", "snotty", "discussion", "grade", "illustrious", "automatic", "wretched", "giraffe", "bedroom", "crazy", "dizzy", "alert" };
        #endregion



        public HangmanGamePlay()
        {
            //newGame();
        }

        public void newGame()
        {
            selectRandomWord();
            displayedWord.Text = string.Concat(Enumerable.Repeat("_ ", word.Length));
            message.Text = "Good Luck!";
            gueses = 0;
            incorrectGuesses = 0;
            score = 0;
        }

        public int makeGuess(string guess)
        {

            if (!checkGuessCorrect(guess))
            {
                ++gueses;
                ++incorrectGuesses;
            }
            else
            {
                updateDisplayedWord(guess);
            }
            return incorrectGuesses;
        }

        public bool isFinished()
        {
            if (incorrectGuesses == 10 || gueses - incorrectGuesses == word.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool wasGameWon()
        {
            if (gueses - incorrectGuesses == word.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void endGame()
        {
            score = calculateScore();
            List<Users> activeUser = Database.LoadActiveUser();
            string temp = "";
            if (wasGameWon())
            {
                temp = "Congratulations you Guessed the Word!";
                activeUser[0].wins += 1;
            }
            else
            {
                temp = $"Out of moves, the word was {word}.";
                activeUser[0].loses += 1;
            }
            activeUser[0].score += score;
            Database.UpdateUser(activeUser);
            message.Text = $"{temp} Your score was {score}";
        }

        private void selectRandomWord()
        {
            word = words[Operations.randomNumber(0, words.Length)].ToLower();
        }

        private bool checkGuessCorrect(string guess)
        {
            return word.Contains(guess);
        }

        private void updateDisplayedWord(string guess)
        {
            char[] g = guess.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == g[0])
                {
                    ++gueses;
                    displayedWord.Text = new StringBuilder(displayedWord.Text) { [i * 2] = g[0] }.ToString();
                }
            }
        }

        private int calculateScore()
        {
            return (31 - incorrectGuesses * 3) * word.Length;
        }

    }
}