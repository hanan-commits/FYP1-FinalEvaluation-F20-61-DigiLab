# FYP1-FinalEvaluation-F20-61-DigiLab
FYP1 Final Evaluation
DigiLab is an Augmented Reality based application that enables students of Secondary Level to do their lab experiments of Physics using just their Android phones. When a user opens the app, a list of available practicals will be shown to the student. Then, apparatus for the chosen practical will be displayed to the student along with 3D simulation of step-by-step practical. Students can also change the size, weight, etc. of the tools involved in the practical like the mass of bob, etc. The measurements will be updated according to data updated by the student.
The step by step calculation will be shown at the end of the experiment. A Student can also change the objects involved in the experiment from the predefined library of objects or by scanning objects in real-time. For example, he can calculate the difference of the masses of bobs hanging from the Atwood’s machine, while visualizing the tension and impact of higher weights of different bobs.

Constraints:
1.	Android devices with Android version 8.0 Oreo or greater.
2.	Min 3GB RAM.
3.	Only AR Core supported devices.

Implementation:

Perform Practical:

Place Objects:
PlacementController script, in Unity3D, provides the functionality of placing the 3D rendered object, made using SimLab and Unity3D, at the provided coordinates of the 3D Space in Augmented Reality. It occurs in two steps;
1.	ARPlane Manager script detects the horizontal space using AR Foundation’s subsystem known as Plane Manager. It opens the device’s camera and detects horizontals and vertical planes. It then highlights the regions where it detects horizontal space. The user will be able to place objects in the highlighted region only.
2.	ARRayCastManager will then detect the coordinates of the tap by the user and place the object on those coordinates. It works by throwing a ‘ray’ originating from the point of contact of the user tap on the screen to 3D space inscreen. It returns the coordinates in the form of a 3D vector containing xyz coordinates.

Time Based Practicals:
For Time based practicals, the PlacementController will start the timer upon the placement of the objects.

Measurement Based Practicals:
For Measurement Based Practicals, there is no need for a timer.

The PlacementController will be updated at each frame. Whenever the user will choose different objects of varying size and mass, the PlacementController will update the already rendered AR model of the object according to the new size or mass.

