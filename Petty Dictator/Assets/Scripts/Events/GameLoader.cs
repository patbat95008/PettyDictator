using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class GameLoader : MonoBehaviour {
	public GameObject start_tree;
	public GameObject start_event;
	public string dataPath;

	private GameObject game_tree, game_event, game_choice;
	private EventTree tree_script;
	private GameEvent event_script;

	void Start () {
		loadEventData(dataPath);
	}

	//Loads data from a text list containing the following format:
	/* 
	 	Event Tree - Title
		***
		Event 1 – Title 1
		***
		Event 1 Key
		***
		"Briefing 1 Goes Here.
		Blah Blah Blah"
		***
		Choice A – Title
		***
		Event 2 key
		***
		+ Good thing
		+ Good thing 2
		- Bad thing 
		- Bad thing 2
		***
		Choice B – Title
		***
		Event 3 key
		***
		+ Good thing
		+ Good thing 2
		- Bad Thing
		- Bad thing 2
		*** (ETC)
	 */
	void loadEventData(string dataPath){
		int lineScanned = 0;
		StreamReader scanner = new StreamReader(dataPath);

		string treeTitle, eventTitle, eventKey, briefing, choiceA_title, choiceB_title;
		string choiceA_link, choiceB_link;
		ArrayList choice_a_good = new ArrayList();
		ArrayList choice_a_bad = new ArrayList();
		ArrayList choice_b_good = new ArrayList();
		ArrayList choice_b_bad = new ArrayList();

		eventTitle = eventKey = briefing = choiceA_title = 
			choiceB_title = choiceA_link = choiceB_link = "";

		//Init game objects

		//Init master tree - Note, may need to take out
		start_tree = Instantiate(start_tree);
		tree_script = start_tree.GetComponent<EventTree>();

		// Load things //
		tree_script.title = scanner.ReadLine();

		while(scanner.ReadLine() != null){
			//Init events - Note, may need to loop
			game_event = Instantiate(start_event);
			event_script = game_event.GetComponent<GameEvent>();

			event_script.title = getBlock(scanner);

			event_script.key = getBlock(scanner);

			event_script.briefing = getBlock(scanner);

			event_script.choice_a_title = getBlock(scanner);
			getPoints(scanner, event_script.choice_a_good, event_script.choice_a_bad);
			event_script.choice_a_link = getBlock(scanner);

			event_script.choice_b_title = getBlock(scanner);
			getPoints(scanner, event_script.choice_b_good, event_script.choice_b_bad);
			event_script.choice_b_link = getBlock(scanner);
		}
		scanner.Close();
	}

	//Get a block of text from the beginning until it hits '***'
	string getBlock(StreamReader scanner){
		string block = "";
		string line = "";
		do {
			line = scanner.ReadLine();

			if (isBlockEnd(line)){
				//Debug.Log("Skipping: " + line);
				break;
			}else{
				//Debug.Log("line = " + line);
				block += line;
				block += '\n';
			}
		} while (line != null);

		return block;
	}

	//Get points on a list until it hits '***'
	//Gets good points from a '+' as char 0
	//Gets bad points from a '-' as char 0
	void getPoints(StreamReader scanner, ArrayList goodPoints, ArrayList badPoints){
		string line = "";
		do {
			line = scanner.ReadLine();
			if(isBlockEnd(line)) { break; }
			//Debug.Log("Point:" + line);

			if(line[0]=='+')
				goodPoints.Add(line.Substring(1));
			else if(!isBlockEnd(line))
				badPoints.Add(line.Substring(1));
			
		}while (line != null);
	}

	bool isBlockEnd(string line){
		if(line == null || line.Equals("***") || line.Equals("---") 
			|| line.Equals("****") || line.Equals("----"))
			return true;
		else 
			return false;
	}
}
