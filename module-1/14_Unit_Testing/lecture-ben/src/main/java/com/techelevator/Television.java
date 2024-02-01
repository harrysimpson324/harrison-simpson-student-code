package com.techelevator;

public class Television {
    private boolean isOn = false;
    private int channel = 1;
    private int maxChannels = 4;
    private int volume = 0;

    public int changeChannel(int changeByAmount) {
        while (changeByAmount-- > 0) {
            channel++;
            if (channel > maxChannels) {
                channel = 1;
            }
        }
        return channel;
    }

}
