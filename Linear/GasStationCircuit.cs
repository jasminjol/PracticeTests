using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int station;
            station = CanCompleteCircuit(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 3, 4, 5, 1, 2 });
            Console.WriteLine("Start station: " +station.ToString());

            station = CanCompleteCircuit(new List<int>() { 3, 4, 3, 2, 5 }, new List<int>() { 6, 4, 5, 1, 2 });
            Console.WriteLine("Start station: " + station.ToString());

            station = CanCompleteCircuit(new List<int>() { 4, 6, 7, 4 }, new List<int>() { 6, 5, 3, 5 });
            Console.WriteLine("Start station: " + station.ToString());
            Console.ReadKey();
        }

        static int CanCompleteCircuit(List<int> availableGas, List<int> neededGas)
        {
            //base case if total available gas is less than total neededGas then no solution is possible
            if (availableGas.Sum() < neededGas.Sum()) return -1;

            //initalization
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int queueGas = availableGas[0] - neededGas[0];
            int current = 1;

            //logic
            while (queue.Count != 0 && current < availableGas.Count && current != queue.Peek())
            {
                //deque till you get positive or zero gas
                while (queue.Count != 0 && queueGas < 0)
                {
                    int index = queue.Dequeue();
                    queueGas += (neededGas[index] - availableGas[index]);
                }

                queueGas = (queueGas + availableGas[current]) - neededGas[current];
                queue.Enqueue(current);
                current = (current + 1) % availableGas.Count;
            }

            return queue.Peek();
        }
    }
}
