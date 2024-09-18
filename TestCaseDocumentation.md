# Test Case Documentation: Old Phone Pad Solution

## Project Overview:
This project implements an old phone pad system where numeric inputs are translated into corresponding letters. Special keys include:
- `*` to delete the last character
- `#` to terminate input and display the result
- Space (` `) indicates a pause between keypresses.

## Keypad Mapping:
- `2` -> "ABC"
- `3` -> "DEF"
- `4` -> "GHI"
- `5` -> "JKL"
- `6` -> "MNO"
- `7` -> "PQRS"
- `8` -> "TUV"
- `9` -> "WXYZ"

## Testing Overview:
Each test case below contains an input sequence, an expected output, and a description of the case. The tests are designed to cover:
1. Basic functionality
2. Input termination with `#`
3. Handling of the `*` key for deletions
4. Spaces between keypresses
5. Special edge cases

## Test Cases:

### Test Case 1: Single Letter Output
- **Input:** `33#`
- **Expected Output:** `E`
- **Description:** The input `33#` maps to the letter "E" since the second character of the `3` key corresponds to "DEF". The `#` ends the input.

### Test Case 2: Backspace Functionality
- **Input:** `227*#`
- **Expected Output:** `B`
- **Description:** 
  - `22` results in the letter "B" (second letter of `2` key).
  - `7` starts input for a letter from "PQRS" but the `*` backspaces (deletes the last character).
  - Input ends with `#` resulting in the output "B".

### Test Case 3: Simple Word
- **Input:** `4433555 555666#`
- **Expected Output:** `HELLO`
- **Description:** 
  - `44` -> `H`
  - `33` -> `E`
  - `555` -> `L`
  - `555` -> `L`
  - `666` -> `O`
  - The space is ignored.
  - The input terminates with `#`.

### Test Case 4: Combination of Backspace and Valid Input
- **Input:** `8 88777444666*664#`
- **Expected Output:** `TURING`
- **Description:** 
  - `8` -> `T`
  - `8877` -> `UR`
  - `444` -> `I`
  - `666` -> `N`
  - `*` backspaces and removes the letter `N`
  - `664` restores the letter `N`, and `G` is added from `4`.
  - The input terminates with `#`.

### Test Case 5: Edge Case with Immediate Backspace
- **Input:** `2*#`
- **Expected Output:** (Empty String)
- **Description:** 
  - `2` starts the sequence for "ABC".
  - `*` backspaces and deletes the only character entered.
  - The input terminates with `#`, resulting in an empty output.

### Test Case 6: Multiple Backspaces and Input Reset
- **Input:** `555*55*5#`
- **Expected Output:** `L`
- **Description:** 
  - `555` -> `L`
  - `*` deletes `L`.
  - `55` -> `K`.
  - `*` deletes `K`.
  - `5` -> `J`.
  - The input terminates with `#`.

### Test Case 7: Input Without Termination
- **Input:** `999`
- **Expected Output:** (No output)
- **Description:** 
  - Without a terminating `#`, the system should not output anything as input has not completed.

### Test Case 8: Consecutive Same Keypresses Without Pausing
- **Input:** `7777#`
- **Expected Output:** `S`
- **Description:**
  - Pressing `7` four times results in the fourth character of "PQRS", which is `S`.
  - The input terminates with `#`.

### Test Case 9: Word with Mixed Inputs and Pauses
- **Input:** `44 33 555 555 666#`
- **Expected Output:** `HELLO`
- **Description:** 
  - Spaces between keypresses act as pauses but do not affect the result.

### Test Case 10: Multiple Characters from Same Key
- **Input:** `777733#`
- **Expected Output:** `SD`
- **Description:**
  - `7777` -> `S`.
  - `33` -> `D`.
  - The input terminates with `#`.

## Conclusion:
These test cases are designed to ensure the correctness of the `OldPhonePadSolution` function. They cover a variety of scenarios, including normal inputs, edge cases, and backspace functionality. Testing these cases will ensure that the implementation meets all expected requirements for translating old phone pad inputs into corresponding text output.