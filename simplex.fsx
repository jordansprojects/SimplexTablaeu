
//open System for console reading 
open System
//import regex for interpreting users input
open System.Text.RegularExpressions

let coefficient_regex = "\d+(?=[a-z])"

let print_menu() =
 let menu = "*****************SIMPLEX ALGORITHM SIMULATOR***********************" + "\n a - enter linear optimization model and solve. " + "\n b - use sample linear optimization model. " + "\n q - quit. " + "\n*******************************************************************"
 printfn "%s" menu

let print_directions() = 
 let directions = "Write your LO model in the following format ; "+"\nmax 3x + 7y + 2z"+"\n2x + 9y + 3z = 43"+"\n7z = 1"+"\n..... however many constraints you choose."+"\nFirst the objective function, then your constraints. Each on their own line."+"\nThen end with EOF ( CTRL-D ) . "
 printfn "%s" directions

let confirm()=
 printfn "Is this correct? Y\N"
 let confirmation = Console.ReadLine().[0]
 confirmation

let retrieve_option() = 
 printfn "Make your selection : "
 let selection = Console.ReadLine()
 selection.[0]


//  count_variables : Tells how many variables there are in the LO-Model
// @param lis: the list of user input
// @return: the list of variables (the # of variables is inferred from the size of the list)
let count_variables(lis:list<string>)  =
  Regex.Replace((lis |> String.concat ""), "\d|\s|\+|-|=|max|min", "") |> Seq.toList |> Seq.distinct


//read_input : reads user input until EOF is activated
// @return : list of lines of user input
// Pulled from the following  StackOverflow article for this function:
// https://stackoverflow.com/questions/27795828/read-unknown-number-of-lines-in-f
let read_input() =
  let read _ = Console.ReadLine()
  let isValid = function null -> false | _ -> true
  let inputList= Seq.initInfinite read |> Seq.takeWhile isValid |> Seq.toList
  inputList


let perform_simplex() =
 printfn "I do nothing. I am useless."


// Turns the raw user input into simplex tableau that the program can work with
let parse_input(raw_list:list<string>) = 
 let vars = count_variables(raw_list.Tail) 
 printfn "Debug, variables in this LO Model : "
 vars |> Seq.iter (printfn "%c")
 let objective_func = raw_list.[0]
 printfn "obj function: %s" objective_func

 


let init_simplex() =
 print_directions()
 let lis = parse_input(read_input())

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





