/`x* snip-imports */
open System
/* snip-exception */
exception GcdError of string
/* snip-gcdbegin */
let gcd a b =
   /* snip-gcdinner */
   let rec gcdpure a b =
     match b with
       | 0 -> a
       | _ -> gcdpure b (a % b)
   /* snip-abs */
   if a >= 0 && b > 0 then
      gcdpure a b
   else
      raise (GcdError("b cannot be zero"))
/* snip-gcdend */

/* snip-writebegin */
Console.WriteLine("gcd({0},{1}) = {2}", 0, 5, gcd 0 5)
Console.WriteLine("gcd({0},{1}) = {2}", 5, 100, gcd 5 100)
Console.WriteLine("gcd({0},{1}) = {2}", 25, 35, gcd 25 35)
/* snip-writeend */

/* snip-mainbegin */
try
   Console.WriteLine("gcd({0},{1}) = {2}", 5, 0, gcd 5 0)
with
   | GcdError(text) -> printfn "expected exception %s" text
/* snip-mainend */