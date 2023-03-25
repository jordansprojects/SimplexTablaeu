//open System for console reading 
open System
//import regex for interpreting users input
open System.Text.RegularExpressions

// REGEX CONSTANTS
// this regex grabs all digits before an occurance, we use
// string addition later so that its variable specific
// TO-DO : fix regex so negative sign is grabbed as well
let COEFFICIENT_REGEX = "(\d+)" 
let VARIABLE_REGEX= "\d|\s|\+|-|=|max|min|\/|"

// list of strings for example model, this will be modified so that a random model can be generated each run
let example_model = ["max 35x + 17y + 202z"; "2x + 999y + 34z = 43"; "7z + 13x = 1"]

// STRING MENU CONSTANTS
let directions = "Write your LO model in the following format ; \nmax 3x + 7y + 2z\n2x + 9y + 3z = 43\n7z = 1\n..... however many constraints you choose.\nFirst the objective function, then your constraints. Each on their own line, each component seperated by a space .\nThen end with EOF ( CTRL-D ) . " 
let menu = "|*****************| SIMPLEX TABLEAU SIMULATOR |***********************\n a - enter linear optimization model and solve. " + "\n b - use sample linear optimization model. \n q - quit. \n*******************************************************************|\nMake your selection : "

// This currently is not being used and may be deleted. 
let confirm()=
 printfn "Is this correct? Y\N"
 let confirmation = Console.ReadLine().[0]
 confirmation

// retrieve_total_variables
// @param lis: the list of user input
// @return: the list of variables (the # of variables is inferred from the size of the list)
let retrieve_total_variables(lis:list<string>)  =
  Regex.Replace((lis |> String.concat ""), VARIABLE_REGEX, "") |> Seq.toList |> Seq.distinct |> Seq.toList



//TODO: function to combine like terms

//read_input : reads user input line by line until EOF is activated
// @return : list of lines of user input
// Pulled from the following  StackOverflow article for this function:
// https://stackoverflow.com/questions/27795828/read-unknown-number-of-lines-in-f
let read_input() =
  printfn "%s" directions
  let read _ = Console.ReadLine()
  let isValid = function null -> false | _ -> true
  let inputList= Seq.initInfinite read |> Seq.takeWhile isValid |> Seq.toList
  inputList


let perform_simplex(table:double[,]) =
  printfn "I do nothing. I am useless."


let init_simplex(vars:list<char>, model:list<string>) =
  perform_simplex(Array2D.create 2 3 1.0) 


// Turns the raw user input into simplex tableau that the program can work with
// @param model : list of equation strings
// @return a 2D array; a simplex tableau
let parse_input(model:list<string>) = 
  // Retrieve variables , determine how many there are 
  let vars = retrieve_total_variables(model) 
  printfn "Your Model:" // Display to user their model
  model|> Seq.iter (fun x -> printfn "%s" x)
  
  // Create Coefficient Matirix by parsing input data line by line,
  // Using the coefficient regex to grab each variable 
  let array = Array2D.init model.Length  vars.Length (fun i j ->
   let regex = Regex((COEFFICIENT_REGEX + string vars.[j]))
   if regex.Match(model.[i] ).Success then double (Regex.Replace(regex.Match(model.[i] ).Value, string vars.[j], "")) else 0.0 )
   
  // print array
  printfn "DEBUG : array thus far:\n %A" array
  

// Main function
let main  =
 printfn "%s" menu
 let opt = Console.ReadLine().[0]
 match opt with
  | 'a'-> parse_input(read_input())
  | 'b' -> parse_input(example_model)
  | 'q' -> printfn "Goodbye."
  | _  -> printfn "Invalid Input."
 0

