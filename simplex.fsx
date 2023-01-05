
//open System for console reading 
open System
//import regex for interpreting users input
open System.Text.RegularExpressions


let print_menu() =
 let menu = "*****************SIMPLEX ALGORITHM SIMULATOR***********************" + "\n a - enter linear optimization model and solve. " + "\n b - use sample linear optimization model. " + "\n q - quit. " + "\n*******************************************************************"
 printfn "%s" menu


let retrieve_option() = 
 printfn "Make your selection : "
 let selection = Console.ReadLine()
 selection.[0]

//read_input : reads user input until EOF is activated
// @return : list of lines of user input
// Referenced the following  StackOverflow article to get this method:
// https://stackoverflow.com/questions/27795828/read-unknown-number-of-lines-in-f
let read_input() =
  let read _ = Console.ReadLine()
  let isValid = function null -> false | _ -> true
  let inputList= Seq.initInfinite read |> Seq.takeWhile isValid |> Seq.toList
  inputList

let perform_simplex() =
 printfn "I do nothing. I am useless."


let init_simplex() =
 printfn "Write your LO model in the following format ; "
 printfn "max 3x + 7y + 2z"
 printfn "2x + 9y + 3z = 43"
 printfn "7z = 1"
 printfn "..... however many constraints you choose."
 printfn "First the objective function, then your constraints. Each on their own line."
 printfn "Then end with EOF ( CTRL-D ) . "
 let lis = read_input()
 perform_simplex()



let main  =
 print_menu()
 let opt = retrieve_option()
 match opt with
  | 'a'-> init_simplex()
  | 'b' -> perform_simplex()
  | 'q' -> printfn "Goodbye."
  | _  -> printfn "Invalid Input."
 0





