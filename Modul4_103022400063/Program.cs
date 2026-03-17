// See https://aka.ms/new-console-template for more information

using System.Security;

public class KodePaket
{
    public enum NamaPaket { Basic, Standard, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Traveler }

    public static string getKodePaket(NamaPaket NamaPaket)
    {
        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210" };
        return kodePaket[(int)NamaPaket];
    }
}

public class main
{
    static void Main()
    {

        string[] NamaPaketNames = Enum.GetNames(typeof(KodePaket.NamaPaket));
        Console.WriteLine("Daftar Paket Beserta Kode Paket");
        for (int i = 0; i < NamaPaketNames.Length; i++)
        {
            KodePaket.NamaPaket kel = (KodePaket.NamaPaket)Enum.Parse(typeof(KodePaket.NamaPaket), NamaPaketNames[i]);

            string kodepaket = KodePaket.getKodePaket(kel);

            Console.WriteLine("Paket: {0} | Kode Paket: {1}", kel, kodepaket);
            MesinKopi mesinKopi = new MesinKopi();

            Console.WriteLine("State awal: Off");
            mesinKopi.activateTrigger(MesinKopi.Trigger.Power_On);
            Console.WriteLine("State setelah  trigger Power_ON, maka");
            mesinKopi.activateTrigger(MesinKopi.Trigger.Start_Brew);
            Console.WriteLine("State menengah: MEsin mulai kerja");
            mesinKopi.activateTrigger(MesinKopi.Trigger.Power_Off);
            Console.WriteLine("State setelah  trigger PowwerOF, maka");
           

        }
    }
}

public class MesinKopi
{
    public enum State { Off, Standbay,Brewing,Maintenance };
    public enum Trigger { Power_On, Power_Off, Start_Maintenance, Finish_Maintenance,Start_Brew,Finish_Brew }
    class transition
    {
        public State prevState;
        public State nextState;
        public Trigger trigger;
        public transition(State currentState, State nextState, Trigger trigger)
        {
            this.prevState = currentState;
            this.nextState = nextState;
            this.trigger = trigger;
        }
    }

    transition[] transitions = {
        new transition(State.Off, State.Standbay, Trigger.Power_On),
        new transition(State.Standbay, State.Brewing, Trigger.Start_Brew),
        new transition(State.Brewing, State.Standbay, Trigger.Finish_Brew),
        new transition(State.Maintenance, State.Standbay, Trigger.Finish_Maintenance),
        new transition(State.Standbay, State.Off, Trigger.Power_Off),
        new transition(State.Standbay, State.Maintenance, Trigger.Start_Maintenance)

    };

    public State currentState;
    public MesinKopi()
    {
        currentState = State.Off;
    }

    public State getNextState(State prevState, Trigger trigger)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
            {
                return transitions[i].nextState;
            }
        }
        return prevState;
    }

    public void activateTrigger(Trigger trigger)
    {
        currentState = getNextState(currentState, trigger);

        if (currentState == State.Off)
        {
            Console.WriteLine("Mesin Kopi Mati");
        }
        else if (currentState == State.Standbay)
        {
            Console.WriteLine("Mesin Kopi StandBay");
        }
        else if (currentState == State.Brewing)
        {
            Console.WriteLine("Mesin Kopi Mulai Brew");
        }
        else
        {
            Console.WriteLine("Mesin Kopi Maintenance");
        }
    }
}

