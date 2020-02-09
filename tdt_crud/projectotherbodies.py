from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectotherbody', methods=['POST'])
def projectotherbody_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _categoryid = content['OtherBodyId']

        sql = "CALL usp_AddOtherBodyToProject(%s, %s)"
        data = (_projectid, _categoryid,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/projectotherbody/<int:id>', methods=['DELETE'])
def delete_projectotherbody(id):
    try:
        sql = "CALL usp_RemoveOtherBodyFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/projectotherbody/<int:projectid>', methods=['GET'])
def projectotherbody(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetOtherBodiesForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)