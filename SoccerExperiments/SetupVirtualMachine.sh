# Install third-party libraries
sudo python3 -m pip install tensorflow
sudo python3 -m pip install --upgrade pip
sudo python3 -m pip install --upgrade tensorflow
sudo python3 -m pip install --upgrade tensorboard
sudo python3 -m pip install --upgrade tensorboardcolab
sudo python3 -m pip install --upgrade prompt-toolkit
sudo python3 -m pip install --upgrade ipython
sudo python3 -m pip install --upgrade google-api-python-client
sudo python3 -m pip install --upgrade google-colab
sudo python3 -m pip install --upgrade google-auth
sudo python3 -m pip install --upgrade nvidia-smi
sudo python3 -m pip install --upgrade keras
sudo python3 -m pip install --upgrade psutil
sudo python3 -m pip install --upgrade setuptools
sudo python3 -m pip install --upgrade mlagents==0.16.1

sudo apt -qq update
sudo apt -qq install npm
sudo apt -qq install xvfb
sudo apt -qq install libgconf-2-4
sudo apt -qq install nodejs-dev node-gyp libssl1.0-dev
sudo apt -qq install gconf-service lib32gcc1 lib32stdc++6 libasound2 libc6 libc6-i386 libcairo2 libcap2 libcups2 libdbus-1-3 libexpat1 libfontconfig1 libfreetype6 libgcc1 libgconf-2-4 libgdk-pixbuf2.0-0 libgl1-mesa-glx libglib2.0-0 libglu1-mesa libgtk2.0-0 libnspr4 libnss3 libpango1.0-0 libstdc++6 libx11-6 libxcomposite1 libxcursor1 libxdamage1 libxext6 libxfixes3 libxi6 libxrandr2 libxrender1 libxtst6 zlib1g debconf

sudo apt-get update
sudo apt-get install pulseaudio
sudo apt-get install libgtk-3-dev
sudo apt-get install libarchive-tools

# Download and run Unity installer
wget http://beta.unity3d.com/download/292b93d75a2c/UnitySetup-2019.1.0f2 -O UnityInstaller
chmod +x UnityInstaller
sudo ./UnityInstaller --unattended --components=Unity --install-location=/opt/Editor/Unity

# Create Unity manual activation file
cd /opt/Editor/Unity/Editor
sudo ./Unity -nographics -logFile -batchmode -createManualActivationFile

# Move Unity manual activation file to Home directory
sudo mv Unity_v2019.1.0f2.alf /home/rsaenz
cd /home/rsaenz

# At this point, we need to open https://license.unity3d.com/manual to request a Unity license using the manual activation file

# Move Unity License to Home directory (Needs to be run in a different Terminal session)
gcloud compute scp --recurse INSTANCE_NAME:/home/rsaenz/Unity_v2019.1.0f2.alf /Users/rsaenz/Desktop

# Install Unity license
sudo cp -r "UnityLicense.ulf" "/opt/Editor/Unity/Editor"
cd /opt/Editor/Unity/Editor
sudo ./Unity -nographics -logFile -batchmode -manualLicenseFile UnityLicense.ulf
sudo rm -r -f UnityLicense.ulf
cd /home/rsaenz

# Delete Unity license files
rm -r -f UnityLicense.ulf
rm -r -f Unity_v2019.1.0f2.alf
rm -r -f UnityInstaller

# Clone repository containing the learning environment
git clone -b master https://github.com/rsaenzi/master-thesis.git

# Test ml-agents installation
mlagents-learn -h