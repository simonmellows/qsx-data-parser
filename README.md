# QSX Data Parser
 
This SIMPL Sharp module reads in a CSV-formatted Lutron QSX Integration report from a processor and parses the data to output Hrefs and label info associated with the Lutron components. 

SIMPL Windows demo program included with modified CCI modules to accept serial signal Hrefs rather than parameters.

Currently the only CCI compatible CCI modules are:
- Zone control
- Button control
- LED control
- Area control

## Implementation
- Load the QSX integration report to the Crestron processor and point the module to its file path.
- Input Area Href for each area.
- Input keypad Href for the keypad in each area you want to use for scenes. If left undefined, the Area Scenes will be used (these do not have feedback).

# Future Features:
- Shading module compatibility
