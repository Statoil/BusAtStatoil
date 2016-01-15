
cd C:\systemutvikling\TFS\TETESS\StatoilTransport\PhoneGap
c:

"C:\Program Files\WinRAR\WinRAR.exe" a -afzip -r PhoneGap.zip images js css *.css *.html config.xml

rem https://build.phonegap.com/docs/api
rem c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 -u terje@tessem.net https://build.phonegap.com/api/v1/me
rem c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 -u terje@tessem.net https://build.phonegap.com/token -d "" -X POST

rem c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 https://build.phonegap.com/api/v1/me?auth_token=fukbVcsYMYhnMXUeqown

rem c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 https://build.phonegap.com/api/v1/apps?auth_token=fukbVcsYMYhnMXUeqown

c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 -d 'data={"password":"xxx"}' -X PUT https://build.phonegap.com/api/v1/keys/ios/48247?auth_token=fukbVcsYMYhnMXUeqown
c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 -d 'data={"key_pw":"xxx","keystore_pw":"xxx"}' -X PUT https://build.phonegap.com/api/v1/keys/android/11579?auth_token=fukbVcsYMYhnMXUeqown

c:\appl\curl\curl -k -x http://www-proxy.statoil.no:80 -X PUT -F file=@PhoneGap.zip https://build.phonegap.com/api/v1/apps/280455?auth_token=fukbVcsYMYhnMXUeqown


