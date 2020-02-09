from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectfunder', methods=['POST'])
def projectfunder_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _categoryid = content['FunderId']

        sql = "CALL usp_AddFunderToProject(%s, %s)"
        data = (_projectid, _categoryid,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/projectfunder/<int:id>', methods=['DELETE'])
def delete_projectfunder(id):
    try:
        sql = "CALL usp_RemoveFunderFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/projectfunder/<int:projectid>', methods=['GET'])
def projectfunder(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetFundersForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)