from app import application
from flaskext.mysql import MySQL

mysql = MySQL()
 
# MySQL configurations
#app.config['MYSQL_DATABASE_USER'] = 'admin'
#app.config['MYSQL_DATABASE_PASSWORD'] = '12345678'
application.config['MYSQL_DATABASE_USER'] = 'tdtUser'
application.config['MYSQL_DATABASE_PASSWORD'] = 'Zh8h(^Wp.UNX'
application.config['MYSQL_DATABASE_DB'] = 'tdt'
application.config['MYSQL_DATABASE_HOST'] = 'tdt-test.c26o2raecheb.eu-west-2.rds.amazonaws.com'
##app.config['MYSQL_DATABASE_HOST'] = 'tdtdev2.czut1xdglafi.eu-west-2.rds.amazonaws.com'
mysql.init_app(application)