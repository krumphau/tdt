from app import app
from flask import flash, request, jsonify
import sqlhelper

@app.route('/categories')
def categories():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllCategories()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/category/<int:id>', methods=['GET'])
def category(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetCategory(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/category', methods=['POST'])
def category_add():
    try:
        content = request.json
        _name = content['Name']

        _highlevel = content['HighLevel'] if 'HighLevel' in content else 0

        sql = "CALL usp_InsertCategory(%s, %s)"
        data = (_name, _highlevel,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/category/<int:id>', methods=['DELETE'])
def delete_category(id):
    try:
        sql = "CALL usp_DeleteCategory(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/category/<int:id>', methods=['OPTIONS'])
def options_category(id):
    try:
       resp = jsonify("") 
       resp.headers.add('Access-Control-Allow-Origin', '*')
       resp.headers.add('Access-Control-Allow-Origin', '*')
       resp.headers.add('Access-Control-Max-Age', '1728000')
       resp.headers.add('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, PATCH, OPTIONS')
       resp.headers.add('Access-Control-Allow-Headers', 'Authorization,Content-Type,Accept,Origin,User-Agent,DNT,Cache-Control,X-Mx-ReqToken,Keep-Alive,X-Requested-With,If-Modified-Since')
       resp.headers.add('Content-Length', '0')
       resp.headers.add('Content-Type', 'text/plain charset=UTF-8')
       resp.status_code = 204
       return resp
    except Exception as e:
        print(e)

@app.route('/category/<int:id>', methods=['PUT'])
def update_category(id):
    try:
        content = request.json
        _name = content['Name']
        _highlevel = content['HighLevel'] if 'HighLevel' in content else 0

        sql = "CALL usp_UpdateCategory(%s, %s, %s)"
        data = (id,_name,_highlevel,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
