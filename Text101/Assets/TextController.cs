using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
		cell,mirror,sheets_0,lock_0,cell_mirror,sheets_1,lock_1,corridor_0,
		stairs_0,floor,closet_door,corridor_1,stairs_1,in_closet,stairs_2,
		corridor_2,corridor_3,courtyard
		};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.stairs_0) 	{stairs_0();}
		else if (myState == States.floor) 		{floor();}
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.corridor_1) 	{corridor_1();}
		else if (myState == States.stairs_1) 	{stairs_1();}
		else if (myState == States.in_closet) 	{in_closet();}
		else if (myState == States.stairs_2) 	{stairs_2();}
		else if (myState == States.corridor_2) 	{corridor_2();}
		else if (myState == States.corridor_3) 	{corridor_3();}
		else if (myState == States.courtyard) 	{courtyard();}
	}
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
	
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	
	void cell_mirror() {
		text.text = "Standing in the cell with mirror in hand you hope noone checks in. " +
					"There are some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;}
	}
	   
	
	void sheets_0 () {
		text.text = "Your bunk lays in dissaray. The sheets are long past due " +
					"for a change.\n\n" +
					"Press R to Return.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void sheets_1 () {
		text.text = "Even with the mirror in hand, " +
					"the bed does not seem appealing.\n\n" +
					"Press R to Return.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	void mirror () {
		text.text = "You avoid meeting your eye in the old mirror. " +
					"You notice it seems to be loose.\n\n" +
					"Press T to take the mirror, or R to Return.";
		
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void lock_0() {
		text.text = "A keypad sits next to the door. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return." ;
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;}
    }
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the outer keypad. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and feel a rush of adrenaline as you hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
    }
	void corridor_0() {
		text.text = "You are standing in the corridor outside your cell. " +
					"While happy to be a step closer to freedom, you know " +
					"that you are not home free yet.\n\n" +
					"You see some stairs leading upward and a closet " +
					"at the end of the corridor. \n\n" +
					"Press S to go up the stairs, C to check the Closet or F to look at the floor";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown(KeyCode.F)) {
		myState = States.floor;
		} else if (Input.GetKeyDown(KeyCode.C)) {
		myState = States.closet_door;}
	}
	void corridor_1() {
		text.text = "You are standing in the corridor outside your cell. \n" +
					"You have a hairclip clutched in your hot little hand.\n" +
					"You see some stairs leading upward and a closet " +
					"at the end of the corridor. \n\n" +
					"Press S to go up the stairs or C to check the Closet";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1;
		} else if (Input.GetKeyDown(KeyCode.C)) {
		myState = States.in_closet;}
	}
	void corridor_2() {
		text.text = "You are standing in the corridor outside your cell. \n" +
					"The closet door stands open, cleaning products barely visible in the gloom." +
					"The promise of freedom calls to you as you eye the stairs. \n\n" +
					"Press S to go up the stairs or D to Dress in the uniform.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_2;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_3;}
	}
	void corridor_3() {
		text.text = "The uniform fits suprisingly well. \n" +
					"You eye the stairs and say a quick prayer that your plan will work. \n\n" +
					"Press S to go up the stairs.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.courtyard;
			}
		}
	void stairs_0() {
		text.text = "You begin to climb the stairs when you hear voices.\n" +
					"It must be the guards.\n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;}
		}
	void stairs_1() {
		text.text = "You begin to climb the stairs when you hear voices.\n\n" +
					"It seems the guards aren't going anywhere.\n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;}
	}
	void stairs_2() {
		text.text = "You climb the stairs again.\n\n" +
					"The guards can still be heard and you begin to wonder if you should be locked up after all. \n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2;}
	}
	void closet_door() {
		text.text = "You make your way to the closet. " +
					"It is closed and locked. Though the lock seems flimsy.\n\n" +
					"Press R to return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;}
	}

	void in_closet() {
		text.text = "You make your way to the closet. Using your cunning criminal mind " +
					"you realize you can pick the closet door lock with the hairpin.\n" +
					"Inside the closet are various cleaning tools and a janitor's uniform.\n\n" +
					"Press R to return to the corridor or D to Dress in the uniform.";
	if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2;
		} else if (Input.GetKeyDown(KeyCode.D)){
			myState = States.corridor_3;
		}
	}
	void floor() {
		text.text = "Looking down at the filthy floor you notice a hairclip.\n\n" +
					"Seems useful.\n\n" +
					"Press R to return to the corridor or H to pickup the Hairclip";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		} else if  (Input.GetKeyDown(KeyCode.H)) {
		myState = States.corridor_1;
		}
	}
	void courtyard() {
		text.text = "You climb the stairs confidently and stride past the guards without making eye contact. " +
					"Lost in their conversation they don't seem to pay any attention, taking you as a member of facilty staff.\n" +
					"You step into the open courtyard of the prison, cherishing the taste of the open air. You have won your freedom! \n\n" +
					"Press P to play again.";
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;}
		}
}