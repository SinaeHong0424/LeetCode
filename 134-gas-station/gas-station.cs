public class Solution{
    public int CanCompleteCircuit(int[] gas, int[] cost){
        int totalGas=0;
        int totalCost=0;
        int currentGas=0;
        int startIndex=0;
        for (int i=0; i<gas.Length; i++){
            totalGas+=gas[i];
            totalCost+=cost[i];
            currentGas+=gas[i]-cost[i];
            if(currentGas <0){
                startIndex=i+1;
                currentGas=0;
            }
        }return totalGas >= totalCost? startIndex:-1;
    }
}