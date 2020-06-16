using System;

namespace Login
{
    class LoginUsed : Exception { public LoginUsed() : base("This username has already been used.") { } }
    class NoLetters : Exception { public NoLetters() : base("Password doesn't contain any letter.") { } }
    class NoSymbols : Exception { public NoSymbols() : base("Password doesn't contain any symbol.") { } }
    class TheSamePasswordAndNickname : Exception { public TheSamePasswordAndNickname() : base("Password shouldn't be the same as username.") { } }
}
