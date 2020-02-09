from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectvisit', methods=['POST'])
def projectvisit_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _categoryid = content['CategoryId']

        sql = "CALL usp_AddVisitToProject(%s, %s)"
        data = (_projectid, _categoryid,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/projectvisit/<int:id>', methods=['DELETE'])
def delete_projectvisit(id):
    try:
        sql = "CALL usp_RemoveVisitFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/projectvisit/<int:projectid>', methods=['GET'])
def projectvisit(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetVisitsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)