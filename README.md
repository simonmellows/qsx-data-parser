# QSX Data Parser
 
This SIMPL Sharp module reads in a CSV-formatted Lutron QSX Integration report from a processor and parses the data to output Hrefs and label info associated with the Lutron components. 

SIMPL Windows demo program included with modified CCI modules to accept serial signal Hrefs rather than parameters.

Currently the only compatible CCI modules are:
- Zone control
- Button control
- LED control
- Area control
- Shading control

## Implementation
- Load the QSX integration report to the Crestron processor and point the 'CF Lutron Read' module to its file path.
- Input Area Href for each area.
- Input keypad Href for the keypad in each area you want to use for scenes.

## Important Notes
- In Lutron, do not use commas in naming things. As the Crestron modules read CSV (comma separated values), trivial use of commas in naming will cause unexpected behaviour.
- On larger projects (20+ areas), avoid including redundant modules in the program as it will slow the communication between Lutron and Crestron.

# Future Features:
- Ability to determine if a zone is switched or dimmable (will require a different report).

# Bugs
## Open

## Fixed
- Error parsing CSV if there are no shade groups defined in the integration report. If the line "Shade Group Name,href" is missing from the integration report, debugger will produce the following error: "An error occurred: Invalid CSV data format.
  - FIX: If using version with this issue, download latest version and overwrite the clz file in the problematic project (no need to overwrite SIMPL modules).
