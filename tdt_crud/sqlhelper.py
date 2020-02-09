import pymysql
from db_config import mysql
from flask import jsonify

def do_selectmulti(sql):
    try:
        conn = mysql.connect()
        cursor = conn.cursor(pymysql.cursors.DictCursor)
        cursor.execute(sql)
        rows = cursor.fetchall()
        resp = jsonify(rows)
        return resp
    except Exception as e:
        print(e)
    finally:
        cursor.close() 
        conn.close()

def do_selectmultibyid(sql, id):
    try:
        conn = mysql.connect()
        cursor = conn.cursor(pymysql.cursors.DictCursor)
        cursor.execute(sql, id)
        rows = cursor.fetchall()
        resp = jsonify(rows)
        return resp
    except Exception as e:
        print(e)
    finally:
        cursor.close() 
        conn.close()

def do_selectsinglebyid(sql, id):
    try:
        conn = mysql.connect()
        cursor = conn.cursor(pymysql.cursors.DictCursor)
        cursor.execute(sql, id)
        row = cursor.fetchone()
        resp = jsonify(row)
        return resp
    except Exception as e:
        print(e)
    finally:
        cursor.close() 
        conn.close()

def do_writedata(sql, data):
    try:
        conn = mysql.connect()
        cursor = conn.cursor()
        cursor.execute(sql, data)
        conn.commit()
        resp = jsonify("Operation successful")
        return resp
    except Exception as e:
        print(e)        
    finally:
        cursor.close() 
        conn.close()
